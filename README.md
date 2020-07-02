# Promotion Engine 

PriceListService
  - This service load the price list from **PriceList.xml**.
  - Returns price by Sku Id. provided.
  - Get prices of all items as Sku Id, Price pair


    
CartService
  - This service manage basic cart operations - add item , edit item , remove item from the cart
  - Calculates the price based on the cart items.
  - Has a dependency on **IPriceListService**
  

PromotionService 
  - This service calculates the price of the cart items after different types of promotions being applied.
  - This service takes CartService as a component and decorates it as per implementation. (Decorator).
  - This service has many implementations based on promotion types
    - NSku - Promotion based on N number of Sku Ids
    - Fixed Price - Fixed price based on Sku Ids
    - No Promotion - The price should be same as cart price
