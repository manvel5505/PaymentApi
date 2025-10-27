About_   >

In this API, my main objective was to create more segmented code to improve the overall DDD style,
and I also tried to integrate Entity Framework, 
but with more advanced capabilities such as explicit transactions.

This was my first attempt at moving logic into domain-level services. Previously,
I placed the logic in infrastructure-level services and used DTOs within them,
but now I have separated the code into small CRUD operations in domain-level interfaces, 
separating them according to the CQRS principle, and also using generics within asynchronous functions.

I used this approach to keep the logic clean, 
without any application-level or infrastructure-level elements such as EF or DTOs. 
Because this violates the principles of DDD.

OOP - SOLID

**Cons_
tests regrettably missing.


Packages_

AutoMapper Version: 12.0.0
AutoMapper.Extensions.Microsoft.DependencyInjection Version: 12.0.0

Microsoft.EntityFrameworkCore.SqlServer Version: 9.0.0 
Microsoft.EntityFrameworkCore.Tools Version: 9.0.0
Microsoft.EntityFrameworkCore.Design Version: 9.0.0

Swashbuckle.AspNetCore Version: 6.6.2 (Automatically after creating Web Api project)
