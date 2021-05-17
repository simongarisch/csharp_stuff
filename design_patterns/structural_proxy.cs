// csc structural_proxy.cs && structural_proxy && del structural_proxy.exe
using System;


interface IPasswords {
    String GetMasterPassword();
}


class SimonsPasswords : IPasswords {
    public String GetMasterPassword() {
        return "Wubba lubba dub dub";
    }
}


class PasswordsProxy : IPasswords {
    private String user;
    private SimonsPasswords passwords;

    public PasswordsProxy(String user) {
        this.user = user;
        this.passwords = new SimonsPasswords();
    }

    public String GetMasterPassword() {
        String password = this.passwords.GetMasterPassword();
        String hiddenPassword = new String('*', password.Length);
        if (this.user.Equals("Simon")) {
            return password;
        }
        return hiddenPassword;
    }
}


class Program {
    public static void Main() {
        var simonsPasswords = new SimonsPasswords();
        var proxy = new PasswordsProxy("Bob");
        Console.WriteLine(proxy.GetMasterPassword()); // *******************

        proxy = new PasswordsProxy("Simon");
        Console.WriteLine(proxy.GetMasterPassword()); // Wubba lubba dub dub
    }
}
