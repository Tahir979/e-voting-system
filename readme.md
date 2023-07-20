# e-voting System

> This program has been prepared for student societies which is established within Hacettepe University to organize their elections online. Firstly, excel file which is included people who will vote is loaded to the system, then, verification codes that they will be asked to write down when they will vote will be sent. After the candidates have introduced themselves, everyone will submit their verification code and the candidate name they wish to vote for in the form (Google Form) sent to them, and then, this vote excel will be uploaded to the system. After that too, the votes will be counted.

> For an ideal view, run at 1920 * 1080 resolution and 100% scale settings. The program works with [access database](https://www.microsoft.com/en-us/download/details.aspx?id=13255) and [.NET Framework 4.7.2+](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472), download these if necessary.

> - [**Sample Usage Video**](https://drive.google.com/file/d/1JHKNcc4tQnhTHHIA8YiSjpD4AYZLGRov/view?usp=sharing)

## **About Program**

* For election security reasons, this program will only be able to send verification codes to e-mail addresses with **....@hacettepe.edu.tr**. Verification codes will not be sent to e-mail addresses of service providers such as Gmail, Hotmail, Yahoo, Outloook etc.

     * The program will automatically extract the incorrect email addresses and show them to you, so if someone has written the wrong email address, you can contact that person and ask them to correct their email address.

* If the program automatically detects that an email address has been entered more than once, it will only keep one of them in the system, so even if people who want to vote enter their email address more than once, there is no question of sending more than one verification code.

* If the program detects that a verification code has been entered more than once, it will automatically keep only one of them in the system, meaning that even if people who want to vote enter their verification code more than once, they will not be able to cast more than one vote.

* It can also be used for elections where not only one vote but also multiple votes can be cast.

* Vote Counting works by clicking on a closed vote to open it and adding +1 vote to the person who received the vote. It is not possible to click on an opened vote more than once to give more than one vote to the candidate in question.

## **NuGet Packages**

| Name | Version |
| ---- | ------- |
| `MetroModernUI`| [![Nuget](https://img.shields.io/nuget/v/MetroModernUI.svg)](https://www.nuget.org/packages/MetroModernUI/) |
| `Microsoft.Office.Interop.Excel` | [![Nuget](https://img.shields.io/nuget/v/Microsoft.Office.Interop.Excel.svg)](https://www.nuget.org/packages/Microsoft.Office.Interop.Excel) |

## ScreenShot

![main](/e-voting/screenshot/main.png)
![sendingcode](/e-voting/screenshot/sendingcode.png)
![checkingverificationcode](/e-voting/screenshot/checkingverificationcode.png)
![countingvote](/e-voting/screenshot/countingvote.png)
dfgdfgfd