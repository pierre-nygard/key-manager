### MyKeyManager

Revamp project of my an Console Key Manager.
This is an experimental build using GenericHost with a WPF applicaton.


## User Stories

* As a user I want to be able to log in with my user name and personal password.
* As a user I want to be greeted when I log in.
* As a user I want to see all of my Services listed after I log in.
* As a user I want to be able to add new Services from the main view.
* As a user I want to be able to click on a Service in the list and see all the connected Keys, and also be able to delete or change a Key.
* As a user I want to be able to remove a Service only when it has no connected Keys.


## Data Design
The application is using a TransactSQL database with 3 data models. Keys, Services and a single User. 

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
