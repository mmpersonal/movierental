movierental is the web application based of MVC. controller will call Apis in appropriate microsservices ( catalogservice, transactionservice, searchservice, authenticationservice,...)
This abstracts data model / changes and business logic to appropriate services and let this be thin layer that view will interact on
to build browse/discovery/search experience, movie detail experience ( including movie preview in the future) and 
finally renting the movie & integration with payment gateways.
