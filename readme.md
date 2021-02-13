# Bulk HTML Email Sender :+1:

Is there any upcoming party or event? :metal:
And you want to send bulk emails to a list of receipients? No worries! This program will let you send emails to your receipients efficiently!

This program provides:
- [x] Customizable Html Email
- [x] Customizable Distribution List
- [x] Changes Receipient's Name in Html Email *'[[Name]]' is the placeholder*
- [x] Logs in console to whom the email sent successfully
- [ ] User Interface of the App
- [ ] Special Checks & Error Handling 

## Note: Currently its configured with Outlook SMTP
> Modify the EmailSender.cs if you have a different mail server
```csharp
Client.UseDefaultCredentials = true;
Client.Host = "smtp-mail.outlook.com";
Client.Port = 587;
Client.EnableSsl = true;
Client.DeliveryMethod = SmtpDeliveryMethod.Network;
```

The Distribution List file (.csv) will look like this: **Modify before sending**
The first column should have Email Addresses
The second column should have their Names 
![Distribution List in Notepad](/notepad.png)
![Distribution List in Excel](/excel.png)

The sample Html file (.file) is here: **Modify before sending**
![Sample Html Email](/sample.png)

Sample output from the console:
![console.png](/console.png)
Console screenshot. Requires the following: (in order)
1. Path to the Distribution List .csv file
2. Path to the Html Template .html file
3. Subject of the email you're sending
4. Your email credentials (email address and password)

It will output the receipients to whom the email was sent successfully.

### This program is Open Source Software. Feel free to copy/ modify, I won't file against you.