using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using PushSharp.Apple;
using Newtonsoft.Json.Linq;

namespace remoteNotification
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSend.Click += new EventHandler(this.SendMessage);
        }
        void SendMessage()
        {
            SqlDataReader count;
            SqlDataReader dr;
            System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("Conn").ConnectionString);
            string strSql = "select * from APNSDevices";
            cnn.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(strSql, cnn);
            cmd.CommandType = System.Data.CommandType.Text;
            dr = cmd.ExecuteReader();
            // read the .p12 certificate file'
            object appleCert = System.IO.File.ReadAllBytes(Server.MapPath("~\\App_Data\\my.p12"));
            // create a push sharp APNS configuration'
            PushSharp.Apple.ApnsConfiguration config = new PushSharp.Apple.ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, appleCert, "myPassword");
            config.ValidateServerCertificate = false;
            object apnsbRoker = new ApnsServiceBroker(config);
            apnsbROKER.OnNotificationSucceeded += new System.EventHandler(this.Events_OnNotificationSucceeded);
            apnsbROKER.OnNotificationFailed += new System.EventHandler(this.Events_OnNotificationFailed);
            object fbs = new FeedbackService(config);
            fbs.FeedbackReceived += new EventHandler(this.Events_FeedbackReceived);
            while (dr.Read())
            {
                count = (count + 1);
            }

            dr.Close();
            cnn.Close();
            result.Text = ("notification sent" + count);
        }

        private static void Events_FeedbackReceived(string deviceToken, DateTime dateTime)
        {
            System.Diagnostics.Debug.WriteLine("check yourdevice apns if expired");
        }

        private static void Events_OnNotificationSucceeded(ApnsNotification notification)
        {
            System.Diagnostics.Debug.WriteLine("Apple apn sent succeeded");
        }

        private static void Events_OnNotificationFailed(ApnsNotification notification, AggregateExeption exeption)
        {
            exeption.Handle(Function, ex);
            // see what kind of exeption it was to further diagnose'
            if ((ex.GetType() == ApnsNotificationExeption))
            {
                object notificationExeption;
                ex;
                ApnsNotificationExeption;
                // ApnsNotificationExeption.ErrorStatusCode'
                // deal with the failed notification'
                object apnsNotification = notificationExeption.Notification;
                object statusCode = notificationExeption.ErrorStatusCode;
                // notificationExeption.Notification.DeviceToken'
                System.Diagnostics.Debug.Writeline(("Apple Notification Failed: ID="
                                + (notification.Identifier + (", Code="
                                + (statusCode + ("Token:"
                                + (notificationExeption.Notification.DeviceToken + "}")))))));
            }
            else
            {
                // inner exeption might hold more infirmation like an ApnsConnectionExeption'
                System.Diagnostics.Debug.WriteLine("Apple notification Failed for some unknown reason:       {ex.InnerExeption}");
            }

        }

    }
}


______________________________________________________________________________________________________________________________________________
    https://www.youtube.com/watch?v=rO2_PLo-3Eo&t=890s
    Imports System.Data.SqlClient;
Imports PushSharp.Apple;
Imports Newtonsoft.Json.Linq;

Public Class _Default
  Inherits System.Web.UI.Page
Protected

Sub sendMessage()
   Dim count As SqlDataReader
   Dim dr As SqlDataReader
   Dim cnn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("Conn").ConnectionString)
   Dim strSql As String = "select * from APNSDevices"
   cnn.Open()
   
   Dim cmd As New SqlClient.SqlCommand(strSql, cnn)
   cmd.CommandType = CommandType.Text

   dr = cmd.ExecuteReader()

   'read the .p12 certificate file'
   Dim appleCert = System.IO.File.ReadAllBytes(Server.MapPath("~\App_Data\my.p12"))

   'create a push sharp APNS configuration'
Dim config As New PushSharp.Apple.ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production,appleCert,"myPassword")
config.ValidateServerCertificate = False
    'create a apnsservice broker'
Dim apnsbRoker = new ApnsServiceBroker(config)
AddHandler apnsbROKER.OnNotificationSucceeded, AddressOf Events_OnNotificationSucceeded
AddHandler apnsbROKER.OnNotificationFailed, AddressOf Events_OnNotificationFailed
dim fbs = new FeedbackService(config)
Addhandler fbs.FeedbackReceived, AddressOf Events_FeedbackReceived

   While dr.Read()


        count = count + 1
  
   End While

   dr.Close()
   cnn.Close()
result.Text = "notification sent" & count
End Sub
Private Shared Sub Events_FeedbackReceived(deviceToken As String, dateTime As Date)
Debug.Writeline("check yourdevice apns if expired")
End Sub
Private Shared Sub Events_OnNotificationSucceeded(notification As ApnsNotification)
Debug.Writeline("Apple apn sent succeeded")
End Sub
Private Shared Sub Events_OnNotificationFailed(notification As ApnsNotification, exeption As AggregateExeption)
exeption.Handle(Function(ex))
'see what kind of exeption it was to further diagnose'
If TypeOf ex Is ApnsNotificationExeption Then
Dim notificationExeption = DirectCast(ex, ApnsNotificationExeption)
'ApnsNotificationExeption.ErrorStatusCode'

'deal with the failed notification'
Dim apnsNotification = notificationExeption.Notification
Dim statusCode = notificationExeption.ErrorStatusCode
'notificationExeption.Notification.DeviceToken'
Debug.Writeline("Apple Notification Failed: ID=" & notification.Identifier & ", Code=" & statusCode & "Token:" & notificationExeption.Notification.DeviceToken & "}")
Else
'inner exeption might hold more infirmation like an ApnsConnectionExeption'
Debug.WriteLine("Apple notification Failed for some unknown reason:       {ex.InnerExeption}")
End

End Sub










End if
 'Mark it as handled'
Return true
End Function)
End Sub