using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Aquality.Selenium.Browsers;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace DataDrivenKsp.Utils.GmailUtils
{
    internal static class GmailUtil
    {
        private static GmailService service;
        private static IList<Message> messages;

        public static void CreateGmailService()
        {
            string[] Scopes = { GmailService.Scope.MailGoogleCom};
            string ApplicationName = "Test";

            UserCredential credential;

            using (FileStream stream =
                new FileStream("Creds//credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public static IList<Message> ReceiveMessages()
        {
            CreateGmailService();
            UsersResource.MessagesResource.ListRequest MessageRequest = service.Users.Messages.List("me");
            return MessageRequest.Execute().Messages;
        }

        public static Message GetLastMessageData()
        {
            UsersResource.MessagesResource.GetRequest messageRequest = service.Users.Messages.Get("me", messages[0].Id);
            return messageRequest.Execute();
        }

        public static string GetLastMessage()
        {
            messages = ReceiveMessages();
            string messageText = GetLastMessageData().Snippet;
            AqualityServices.Logger.Info($"Last Gmail message: '{messageText}'");
            return messageText;
        }

        public static void DeleteLastMessage()
        {
            UsersResource.MessagesResource.DeleteRequest messageRequest = service.Users.Messages.Delete("me", messages[0].Id);
            messageRequest.Execute();
        }
    }
}
