# key-manager

This is a revamp project of my old Console Key Manager.

Building this one using WPF while I'm learning how to use Generic Host. This became a fun experiment on how to use GH with WPF Applications.



## User Stories

* As a user I want to be able to log in with my user name and personal password.
* As a user I want to be greeted when I log in.
* As a user I want to see all of my Services listed after I log in.
* As a user I want to be able to add new Services from the main view.
* As a user I want to be able to click on a Service in the list and see all the connected Keys, and also be able to delete or change a Key.
* As a user I want to be able to remove a Service only when it has no connected Keys.

## Purpose

To be able to house and edit more than one Key or Pass-phrase for any Services I'm using.

Thing I learned from my last project was that a Service might have 2 or more keys, so I had to duplicate services. 

## Data Design

Application is using a relational database and EF Core

| User     | Interaction |
| -------- | ----------- |
| ID       | Service     |
| UserName |             |
| Password |             |

| Service | Interaction |
| :------ | ----------- |
| ID      | Player      |
| Name    |             |
| UserID  |             |


| Key       | Interaction |
| --------- | ----------- |
| ID        | Service     |
| Value     |             |
| ServiceID |             |

## Graphic Design

![Authentication Window](/StaticResources/log-in-screen.png "Authentication Window")

![Main Window](/StaticResources/main-screen.png "Main Window")
