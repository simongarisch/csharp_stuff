// https://support.microsoft.com/en-us/topic/how-to-use-the-microsoft-outlook-object-library-to-retrieve-a-message-from-the-inbox-by-using-visual-c-94f51fa2-bb49-517b-5ac3-5e1e640e637d
using System;
using System.Reflection; // to use Missing.Value
using Outlook = Microsoft.Office.Interop.Outlook;


class Demo {
    public void Run() {
        Outlook.Application oApp = new Outlook.Application();
        var oNS = oApp.GetNamespace("mapi");

        oNS.Logon(Missing.Value, Missing.Value, false, true);

        Outlook.MAPIFolder oInbox = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        Outlook.Items oItems = oInbox.Items;
        oItems.Sort("[ReceivedTime]", true); // descending

        Outlook.MailItem oMsg = (Outlook.MailItem)oItems.GetFirst();

        // show some common properties
        Console.WriteLine(oMsg.Subject);
        Console.WriteLine(oMsg.SenderName);
        Console.WriteLine(oMsg.ReceivedTime);
        Console.WriteLine(oMsg.Body);

        int AttachCount = oMsg.Attachments.Count;
        Console.WriteLine("Attachments: " + AttachCount.ToString());

        for (int i = 1; i <= AttachCount; i++) {
            Console.WriteLine(i.ToString() + " - " + oMsg.Attachments[i].DisplayName);
        }
        Console.WriteLine("----------");

        // oMsg.Display(true);
        long counter = 0;
        foreach(var oItem in oItems) {
            // get the mail item
            Outlook.MailItem oMsgItem;
            try {
                oMsgItem = (Outlook.MailItem)oItem;
            } catch (System.InvalidCastException) {
                continue; // may be a calendar item or other object
            }

            Console.WriteLine(oMsgItem.Subject);

            // check if we have any attachments
            int numAttachments = oMsgItem.Attachments.Count;
            for(int i=1; i<=numAttachments; i++) {
                var attachment = oMsgItem.Attachments[i];
                string displayName = attachment.DisplayName;
                Console.WriteLine(" *** Attachment " + i.ToString() + " - " + displayName);
                if (displayName == "myTargetFile.png") {
                    attachment.SaveAsFile(displayName);
                    Console.WriteLine("*** ATTACHMENT SAVED ***");
                }
            }

            // don't go through all of them
            counter++;
            if (counter > 10) {
                break;
            }
        }
        
        oNS.Logoff();
    }
}


class Program {
    public static void Main(string[] args) {
        var demo = new Demo();
        demo.Run();
        Console.ReadKey();
    }
}
