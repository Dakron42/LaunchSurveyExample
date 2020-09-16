using System;
using System.Net;

namespace EmailLaunchTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var launchSvc = new LaunchSvc.LaunchManagement();
            NetworkCredential netCredential = new NetworkCredential("qv_test", "qv_test");
            Uri uri = new Uri(launchSvc.Url);
            ICredentials credentials = netCredential.GetCredential(uri, "Basic");
            launchSvc.Credentials = credentials;

            var formID = 41518314;
            var questionId = 84512940;

            var autofillDataItem = new LaunchSvc.WSAutofillDataItem();
            autofillDataItem.questionId = questionId;
            autofillDataItem.answers = new string[] { "THIS_IS_A_TOKEN",
                "SOMEUNIQUESURVEYID",
                "ThisIsAUserId",
                "SomeOtherPRefilled Data",
                "Some other prefilled data"
            };
            var autofillData = new LaunchSvc.WSAutofillData[] {new LaunchSvc.WSAutofillData() };
            autofillData[0].email = "fakeEmail@keysurvey2.com";
            autofillData[0].items = new LaunchSvc.WSAutofillDataItem[] {autofillDataItem};
            var result = launchSvc.getUniqueUrlWithAutofillByEmail(formID, LaunchSvc.WSUrlType.SECURE, true, autofillData);
            Console.WriteLine(result[0].link);
            }
    }
}
