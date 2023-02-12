using System.ComponentModel;
using Avalonia.Controls;

namespace AIMAS;

public partial class MainWindow : Window {
    public MainWindow()
    {
        InitializeComponent();
        // Pass MainWindow's variables into the getData for local use
        LoginAuth.getData(txtPassword.Text, txtUsername.Text);
        // Set context for data binding in AXAML file
        DataContext = new LoginAuth();
    }
}

public class LoginAuth : INotifyPropertyChanged {
    // Variable Assignments
    public static string txtPassword, txtUsername;
    string initalText = "Login";

    // Gets and assigns both variables from MainWindow into local scope due to inheritance causing a memory leak.
    public static void getData(string txtPasswordC, string txtUsernameC) {
        txtPassword = txtPasswordC;
        txtUsername = txtUsernameC;
    }

    // Updates the button's text
    public string AuthButtonText {
        get => initalText;
        set {
            initalText = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthButtonText)));
        }
    }

    // Updates the password
    public string PasswordText {
        get => txtPassword;
        set {
            txtPassword = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(PasswordText)));
        }
    }

    // Updates the username
    public string UsernameText {
        get => txtUsername;
        set {
            txtUsername = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UsernameText)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Checks if data is properly entered
    public void AuthButtonClicked() {
        if(txtUsername == null || txtUsername.Length <= 0) {
            AuthButtonText = "No Username Provided. Try Again";
        } else {
            AuthButtonText = "Incorrect Password. Try Again";
            if(txtPassword == "Password") {
                AuthButtonText = $"Welcome, {txtUsername}";
            }
        }
    }
}