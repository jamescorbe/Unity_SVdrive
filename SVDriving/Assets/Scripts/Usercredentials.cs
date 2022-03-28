using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using TMPro;

public class Usercredentials : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField retypepasswordInput;
    public TextMeshProUGUI userResponse;


    public static string username;
    private static string password;
    private static string reTypePassword;
    public static String currentdir = Directory.GetCurrentDirectory();
    private String usersPath = currentdir + "\\Assets\\Userinfo\\Users.txt";
    public List<string> Users = new List<string>();
   

    void Update()
    {
        Users = File.ReadAllLines(usersPath).ToList();
        username = usernameInput.text;
        password = passwordInput.text;
        

    }
    public String getusername()
    {
        return username;
    }
    public void CreateAccount()
    {
        reTypePassword = retypepasswordInput.text;
        validateNewUser();
    }

    public void validateNewUser()
    {
        Boolean userfound = false;
        foreach(String user in Users)
        {
            user.Split(' ');
            if(user == username)
            {
                userResponse.text = "Username already exists, enter another ";
                userfound = true;
            }
        }
        if(!userfound)
        {
            if(password == reTypePassword)
            {
                if (username.Length > 4 && password.Length > 4)
                {
                    CreateUser();
                }
                else
                {
                    userResponse.text = "username or password length incorrect.";
                }
            }
            else
            {
                userResponse.text = "password doesn't match retype.";
            }
           
        }
        
    }
    public void validateLogin()
    {
      
        for (int i =0; i < Users.Count; i++)
        {
            
            if (Users[i] == username)
            {
               
                if (Users[i + 1] == password)
                 {
                    SceneManager.LoadSceneAsync("Scenes/Startmenu");
                }
            }
        }
            userResponse.text = "Username or password incorrect.";  
    }

    public void CreateUser()
    {
  
        Users.Add(username);
        Users.Add(password);
        Users.Add(" ");
        File.WriteAllLines(usersPath, Users);
        userResponse.text = "User Created!";
        SceneManager.LoadSceneAsync("Scenes/Login");
    }
}



