using System;
using System.IO;
using System.Net;
using absToTango;

class ftp
{
    private string host = null;
    private string user = null;
    private string pass = null;
    private FtpWebRequest ftpRequest = null;
    private FtpWebResponse ftpResponse = null;


    public ftp(string hostIP, string userName, string password) 
	{ 
		host = hostIP; 
		user = userName; 
		pass = password; 
	}

    private void ftpRequestInitialize()
    {
        ftpRequest.Credentials = new NetworkCredential(user, pass);
        ftpRequest.UseBinary = true;
        ftpRequest.UsePassive = true;
        ftpRequest.KeepAlive = true;
    }

    public bool upload(string remoteFile, string localFile)
    {
        bool success = false;
        Stream ftpStream = null;
        int bufferSize = 2048;
        try
        {
            ftpRequest = (FtpWebRequest) FtpWebRequest.Create(host + "/" + remoteFile);
            ftpRequestInitialize();
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            ftpStream = ftpRequest.GetRequestStream();
            FileStream localFileStream = new FileStream(localFile, FileMode.Create);
            byte[] byteBuffer = new byte[bufferSize];
            int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
            try
            {
                while (bytesSent != 0)
                {
                    ftpStream.Write(byteBuffer, 0, bytesSent);
                    bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                }
                success = true;
            }
            catch (Exception e)
            {
                nlog.SaveException(e);
                success = false;
            }
            localFileStream.Close();
            ftpStream.Close();
            ftpRequest = null;
        }
        catch (Exception e)
        {
            nlog.SaveException(e);
            success = false;
        }
        return success;
    }

    public bool delete(string deleteFile)
    {
        bool success = false;
        try
        {
            ftpRequest = (FtpWebRequest) WebRequest.Create(host + "/" + deleteFile);
            ftpRequestInitialize();
            ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
            ftpResponse = (FtpWebResponse) ftpRequest.GetResponse();
            ftpResponse.Close();
            ftpRequest = null;
            success = true;
        }
        catch (Exception e)
        {
            nlog.SaveException(e); 
        }
        return success;
    }

    public bool rename(string currentFileNameAndPath, string newFileName)
    {
        bool success = false;
        try
        {
            ftpRequest = (FtpWebRequest) WebRequest.Create(host + "/" + currentFileNameAndPath);
            ftpRequestInitialize();
            ftpRequest.Method = WebRequestMethods.Ftp.Rename;
            ftpRequest.RenameTo = newFileName;
            ftpResponse = (FtpWebResponse) ftpRequest.GetResponse();
            ftpResponse.Close();
            ftpRequest = null;
            success = true;
        }
        catch (Exception e)
        {
            nlog.SaveException(e); 
        }
        return success;
    }

    public bool createDirectory(string newDirectory)
    {
        bool success = false;
        try
        {
            ftpRequest = (FtpWebRequest) WebRequest.Create(host + "/" + newDirectory);
            ftpRequestInitialize();
            ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
            ftpResponse = (FtpWebResponse) ftpRequest.GetResponse();
            ftpResponse.Close();
            ftpRequest = null;
            success = true;
        }
        catch (Exception e)
        {
            nlog.SaveException(e); 
        }
        return success;
    }
}
