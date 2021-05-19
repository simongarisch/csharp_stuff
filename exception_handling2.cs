// csc exception_handling2.cs && exception_handling2 && del exception_handling2.exe
using System;


class Client {}

class ClientDataAccess {
    public Client GetById(int clientID) {
        if (clientID >= 5) {
            return new Client();
        }
        return null;
    }
}


public class Billing {
    private ClientDataAccess clientDataAccessObject = new ClientDataAccess();

    public void DoBilling(int clientID) {
        Client client = clientDataAccessObject.GetById(clientID);
        if (client == null) {
            throw new ClientBillingException(
                string.Format("Unable to find a client by id {0}", clientID)
            );
        }
    }
}


public class ClientBillingException : Exception {
    public ClientBillingException(string message) : base(message) {}
}


class Program {
    public static void Main() {
        int[] clientIDs = new int[] {7, 6, 5, 4};
        var billing = new Billing();

        foreach(int clientID in clientIDs) {
            try {
                billing.DoBilling(clientID);
                Console.WriteLine("Successfully billed client " + clientID);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                // log ...
            }
        }

        /*
        Successfully billed client 7
        Successfully billed client 6
        Successfully billed client 5
        Unable to find a client by id 4
        */
    }
}
