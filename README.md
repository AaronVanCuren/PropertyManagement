## Welcome to my mock Property Management Website

This is a very basic website that has some of the basic functionality that you would expect when you are on a property management website: Such as: viewing a listing; commenting on a listing; logging into a resident portal if applicable, rating the company, and rating maintenance vendors (if a resident). As a property manager you will be able to create properties that you can later use to create listings without having to create a listing from scratch. When you delete a listing the corresponding property will still be tucked safe away in the database for creating a listing later on. You will also be able to respond to comments on listings and exclusively respone to reviews to the copmany and vendors. There is also a function to allow owners to login, however, there is not functionality beyond that as of right now. Ideally, the onwer and residnet portal should take you to a third-party software website depending on your proeprty manager as this si only a site...not a rent colletion piece of software.

Azure Link: https://lovelylivingpropertymanagement.azurewebsites.net

In order to run the application locally you will need to ensure that the <connectionStrings> inside of Web.config reflects the following:

<connectionStrings>
		<add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=aspnet-PropertyManagement;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>
