# smartData-.NET-Architecture-with-Angular

This is N-Tier Project Architecture created using .NET Core WEB API with Angular Template. In this below mentioned layers created.
1. Common - For all common classes, enums, methods etc.
2. DataContract - All project data models will be added into this layer.
3. RepositoryContact - Will add all interfaces that will support repository classes.
4. Repository - Will add repository classes that will be created on the basis of Repository Contract interfaces. In which all database related interactions will be done through it.
5. ServiceContract - Will add interfaces in it that will support service classes.
6. Service - Will add service classes on the basis of Service Contract and in this we'll write business logic and this'll be intermediate between controller and repository layers.
7. Web - this is an angular template in which we'll write all UI related code etc.
8. Web.API - Will create controllers and web api methods.


Note: After download this sample code may you can get errors related to "Microsoft.Extensions.Configuration.Abstractions.dll", then use below steps to resolve it.
1. Go to Repository layer,  in Dependencies >> Assemblies, then remove "Microsoft.Extensions.Configuration.Abstractions" and then right click on Dependencies and select Add Reference, then click on Browse button, then in Browse dialog box put below path in File Name text box
    C:\Program Files\dotnet\sdk\NuGetFallbackFolder\microsoft.extensions.configuration.abstractions\2.1.1\lib\netstandard2.0 

and then select "Microsoft.Extensions.Configuration.Abstractions.dll" and then click ok. It'll resolve that issue.

Same above step 1, you can do for Service layer if same error persist in it.
