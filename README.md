# Blackbird.io Acclaro

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

MyAcclaro is the portal app for Acclaro, designed to streamline the translation process for their customers. Through MyAcclaro, users can easily create quotes, initiate projects, upload files, and manage their translation needs efficiently.

## Actions

###  File

-**Upload file** Upload a file to an order
-**Search order files** Search for files in an order depending on certain criteria
-**Get file information** Get information of a file
-**Download file** Download order file by ID
-**Get source file** Get the source file that corresponds with a target file

###  Order

-**Create order** Create order
-**Update order** UPdate order
-**Search orders** Search through all orders
-**Get order** Get order by ID
-**Does order exist** Find out whether an order with a certain ID exists
-**Delete order** Delete order
-**Submit order** Submit order
-**Add order comment** Add a new comment to an order
-**Update order comment** Updates an exisitng order comment (note: changes comment ID)
-**Get order comments** Get a list of all comments attached to an order

###  Quote

-**Request quote** Request a quote for an order
-**Approve quote** Approve an order for which a quote was requested
-**Decline quote** Decline an order for which a quote was requested

###  String

-**Get order strings** Get a list of all string of order
-**Add strings to order** Add strings to an existing order. Note: order process type should be string.

## Events

-**On order updated**
-**On order string updated**
-**On order file updated**

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
