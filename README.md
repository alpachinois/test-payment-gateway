# Solution explanation and how to run

The solution respects clean architecture, DDD (domain driven design) and CQRS principes. There is also a bank mock api. You must have .NET 5 support.

To run the gateway, just retrieve sources code and click to start debug. Make sure PaymentGateway.Bank.Mock and PaymentGateway.Api are running in the same time. You can launch several projects as started projects following instruction from this link : https://docs.microsoft.com/en-US/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2022

You can test directly with the swagger interface. The first post request can be tested by this json.

```json
{
   "Merchant":{
      "Name":"test merchant",
      "Id":"68f1072e-ec04-4e56-b9d8-89c43d03466d"
   },
   "Amount":{
      "Value":120,
      "Currency":"EUR"
   },
   "Bank":{
      "Name":"fakeBank",
      "ApiUrl":"https://localhost:44385/"
   },
   "CardInfo":{
      "CardNumber":"1234-5678-9123-7897",
      "Cvv":"123",
      "HolderName":"test",
      "ExpiryMonth":12,
      "ExpiryYear":25
   },
   "Shopper":null
}
```

You can test the route /transactions/transaction by the id retrieved by the preivous request or with this transaction example id : 239287a0-b344-427a-a867-a9142bb7a9e9.
Finally, you can test the route /transactions by the following merchant example id : b8053a59-e449-4e67-8e1b-c588c821eda4.

# Assumptions made

1. It simulates a simple payment gateway between a merchant and a bank.
2. I use a bool for bank response IsSuccess instead of enum status. No enumeration status has been provided by instruction so I simplified the response. 
3. Only card payment is handled.

# Areas of Improvement

1. The first technical improvement is of course the security of the API. There is authentication with for example a OAuth2 protocol implementation. Then, we must secure all secrets of the configuration using a for example some cloud vault technologies (Azure Key Vault or Amazon Key Management Service).
2. The second technical improvement is an implementation of containerisation system with CI/CD yaml. 
3. The third technical improvement could be an infrastructure as code in order to create all cloud resources for each environment (dev, staging and prod for example).
4. Of course, the implementation of Entity Framework Core must be finished. We should create a separate migration and database configuration to another project because the solution will be better in an agnostic storage technologies (NoSQL or classic RDBMS).
5. The final technical improvement is a logging system.
6. Implement an BDD (behavior development design) tests project with Specflow. https://specflow.org/. I also added others tests projects in order to test controllers and dbcontext and repositories with an in memory database.
7. Implement strategy pattern. This could be useful for handling others payment methods. This could be also useful for banking external services.
8. Implement adapter pattern for banking service because each bank must probably has their own APIs.
9. Implement the saga and circuit breaker patterns because this is tipically a distributed system with transactions.

# What cloud technologies you’d use and why

We can use cloud PaaS technology such as AWS PaaS, Azure PaaS or GCP PaaS. We could use templates to deploy resources quickly. Cloud technologies will also provides some very useful like automatic scales, geo-redondancy and advance storage features for data and logs (tracking, queries, reporting). However, I think that any solution must be cloud agnostic in order to by move easily to another provider. 
