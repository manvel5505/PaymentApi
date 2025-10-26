About _>

In this API, my main objective was to create more segmented code to improve the overall DDD style,
and I also tried to integrate Entity Framework, 
but with more advanced capabilities such as transactions.

This was my first attempt at moving logic into domain-level services. Previously,
I placed the logic in infrastructure-level services and used DTOs within them,
but now I have separated the code into small CRUD operations in domain-level interfaces, 
separating them according to the CQRS principle, and also using generics within asynchronous functions.

I used this approach to keep the logic clean, 
without any application-level or infrastructure-level elements such as EF or DTOs. 
Because this violates the principles of DDD.

but tests regrettably missing.

