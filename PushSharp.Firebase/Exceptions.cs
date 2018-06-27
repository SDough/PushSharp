using System;
using System.Collections.Generic;
using PushSharp.Core;
using PushSharp.Firebase.Responses;

namespace PushSharp.Firebase
{
    public class FirebaseNotificationException : NotificationException
    {
        public FirebaseNotificationException(FirebaseNotification notification, string msg) : base (msg, notification)
        {
            Notification = notification;
        }

        public FirebaseNotificationException(FirebaseNotification notification, string msg, FcmMessageErrorResponse description) : base (msg, notification)
        {
            Notification = notification;
            Description = description;
        }

        public new FirebaseNotification Notification { get; private set; }
        public FcmMessageErrorResponse Description { get; private set; }
    }

    public class FirebaseMulticastResultException : Exception
    {
        public FirebaseMulticastResultException() : base ("One or more Registration Id's failed in the multicast notification")
        {
            Succeeded = new List<FirebaseNotification> ();
            Failed = new Dictionary<FirebaseNotification, Exception> ();
        }

        public List<FirebaseNotification> Succeeded { get;set; }

        public Dictionary<FirebaseNotification, Exception> Failed { get;set; }
    }
}

