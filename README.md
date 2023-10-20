# PassWareAPI
Its purpose is to keep important data such as information about the projects carried out in the Company (Company, Project, Jump, Sql, Vpn, RDP, UI, Contacts).
As for technology, I developed a restful web service using ASP.NET Core 7.0 Web API.
Layered architecture was used. I used DataAccess, Business, Entity, Core, WebApi layers. The purpose of using layered architecture is to make the project more smooth and understandable.
-Role Based Authorization and Authentication (Authentication and Authorization):
Authentication and authorization were used to secure the Web API.
Access was granted with role-based authorization.
Secure and scalable management was provided using the JWT (JSON Web Token) authentication mechanism.
-Database Operations (Entity Framework Core):
Entity Framework Core was used for database access and operations.
Database tables were related one-to-many by creating model classes.
Created database queries using LINQ.
- Validation:
Necessary controls have been established to verify and process data.
-Dependency Injection:
The project used the principle of Dependency Injection to increase the flexibility of software components by injecting dependencies.
Autofac Technology Used.
The code was designed with SOLID principles in mind.
Logging:
Logging was used to monitor in-application events and facilitate the debugging process.
Application status was monitored with the ILogger interface.

The following technologies have been used in the project:
<table>
<thead>
<tr>
<th>Tech</th>
</tr>
</thead>
<tbody>
<tr>
<td>ASP.Net Core Web API</td>
</tr>

<tr>
<td>MS SQL Server</td>
</tr>

<tr>
<td>EntityFrameworkCore</td>
</tr>

<tr>
<td>Microsoft.EntityFrameworkCore.Design</td>
</tr>

<tr>
<td>Microsoft.EntityFrameworkCore.Tools</td>
</tr>

<tr>
<td>AutoFac</td>
</tr>

<tr>
<td>Serilog</td>
</tr>

<tr>
<td>Fluent Validation</td>
</tr>

<tr>
<td>Newtonsoft.Json</td>
</tr>

</tbody>
</table>
