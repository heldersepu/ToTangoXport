﻿using System;
using System.Net;
using Newtonsoft.Json;

namespace absToTango
{
    /// <summary>
    /// Provides a simple abstraction layer to the ToTango API, making the pagination transparent.
    /// </summary>
    public class ToTangoReader : IDisposable
    {
        private string _token;
        private string _url = "";
        private string _err = "";
        private int _pos = 0;
        private int _length = 0;
        private int _offset = 0;
        private int _total_items = 0;
        private int _item_count = 0;
        private int _global_item_count = 0;
        private dynamic _dJSON;

        /// <summary>
        /// Initializes a new instance of the ToTangoReader class.
        /// </summary>
        /// <param name="token">Your ToTango API authentication key.</param>
        /// <param name="url">The Url to the API, something like: https://app.totango.com/api/v1/accounts/active_list/1/current.json?return=stats</param>
        /// <param name="length">Optional parameter default to 100.</param>
        public ToTangoReader(string token, string url, int length = 100)
        {
            this._token = token;
            this._url = url.Trim();            
            this._length = (length > 0) ? length : 100;
            this.initJSON();
        }

        /// <summary>
        ///  Gets whether there was an error
        /// </summary>
        public bool Error
        {
            get { return (_err != ""); }
        }

        /// <summary>
        ///  Shows the error message if any
        /// </summary>
        public string ErrorMessage
        {
            get { return _err; }
        }

        /// <summary>
        ///  initialise the dynamic JSON data
        /// </summary>
        private void initJSON()
        {
            if (this._url != "")
            {
                if (!this._url.Contains("?")) this._url += "?";
                string url = this._url + "&length=" + this._length.ToString() + "&offset=" + this._offset.ToString();
                string json = "";
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("Authorization", this._token);
                        json = client.DownloadString(url);
                    }
                    catch (Exception e)
                    {
                        this._err = e.Message;
                        nlog.SaveException(e);
                    }
                }
                if (this._err == "")
                {
                    this._dJSON = JsonConvert.DeserializeObject(json);
                    this._item_count = (int)this._dJSON.current_item_count;
                    this._total_items = (int)this._dJSON.total_items;
                    this._global_item_count += ((_item_count == 0) ? 10 : _item_count);
                }
            }
        }

        /// <summary>
        /// Reads the next account from the underlying stream and advances the current position.
        /// </summary>
        /// <returns>The next account from the stream, or null if no account are available.</returns>
        public dynamic ReadAccount()
        {
            dynamic dAccount = null;
            try
            {
                if (this._global_item_count <= this._total_items)
                {
                    if (this._item_count == this._pos)
                    {
                        this._offset++;
                        this.initJSON();
                        this._pos = 0;
                    }
                    if (this._global_item_count <= this._total_items)
                        dAccount = this._dJSON.accounts[this._pos++];
                }
            }
            catch (Exception e)
            {
                dAccount = null;
                nlog.SaveException(e);
            }
            return dAccount;
        }

        /// <summary>
        /// Reads the name of the current filter from the JSON data
        /// </summary>
        /// <returns>name of the current filter</returns>
        public string ReadName()
        {
            string name = "";
            try
            {
                if (this._dJSON.response_header.name != null)
                    name = this._dJSON.response_header.name.Value;
            }
            catch (Exception e)
            {
                nlog.SaveException(e);
            }
            return name;
        }


        /// <summary>
        /// Releases all resources used by the current instance of the class
        /// </summary>
        public void Dispose()
        {
            this._url = "";
            this._pos = 0;
            this._length = 0;
            this._offset = 0;
            this._total_items = 0;
            this._item_count = 0;
            this._global_item_count = 0;
            this._dJSON = null;
        }
    }
}
