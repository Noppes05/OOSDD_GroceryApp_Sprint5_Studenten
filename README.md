# Git Flow Workflow

Dit project gebruikt **Git Flow** als branching-strategie. Git Flow helpt ons om features, releases en hotfixes gestructureerd te beheren.

## Branches

In Git Flow zijn er een paar vaste branches:

- **main**  
  Bevat altijd de productierijpe code. Alles op `main` is **stabiel** en kan gedeployed worden.

- **develop**  
  Bevat de laatste ontwikkelstatus. Nieuwe features worden hier samengevoegd.

Daarnaast worden tijdelijke branches gebruikt:

- **feature/**  
  Voor nieuwe functionaliteiten.  
  Naamgeving: `feature/omschrijving`  
  → Gebaseerd op `develop` en wordt terug gemerged in `develop`.

- **release/**  
  Voor het voorbereiden van een nieuwe release (bugfixes, documentatie, kleine aanpassingen).  
  Naamgeving: `release/x.y.z`  
  → Gebaseerd op `develop` en wordt gemerged in zowel `main` als `develop`.

- **hotfix/**  
  Voor urgente fixes op productie.  
  Naamgeving: `hotfix/x.y.z`  
  → Gebaseerd op `main` en wordt gemerged in zowel `main` als `develop`.


#GroceryApp sprint5 Studentversie  
Dit is de startversie voor studenten voor sprint 5.  
 
UC15 Toevoegen THT datum aan product is compleet.  

UC14 Toevoegen prijzen:  
- Prijs toevoegen aan product class en uitbreiden constructor chain.  
- ProductRepository --> prijsveld vullen met waarden.  
- ProductView uitbreiden met kolom voor de prijs (header en inhoud van de tabel).      

UC12 Productcategoriën toevoegen --> zelfstandig uitwerken:  
Ontwerp:
>```mermaid
>classDiagram
>direction LR
>    class Product {
>	    +int Id
>	    +string Name
>	    +int Stock
>	    +DateOnly ShelfLife
>	    +Decimal Price
>   }
>    class ProductCategory {
>	    +int Id
>	    +string Name
>	    +int ProductId
>	    +int CategoryId
>    }
>    class Category {
>	    +int Id
>	    +string Name
>    }
>
>    Product "1" -- "*" ProductCategory
>    ProductCategory "*" -- "1" Category
> ```
Stappenplan:  
- Maak class Category  
- Maak class ProductCategory  
- Maak Interface en Repository voor Category  
- Maak Interface en Repository voor ProductCategory  
- Maak Interface en Service voor Category  
- Maak Interface en Service voor ProductCategory  
- Registreer de gemaakte Repo's en services in MauiProgramm  
- Maak CategoriesViewModel.  
- Maak CategoriesView.  
- Registreer De view en het ViewModel in MauiProgramm.  
- Maak een menu entry in de tabbar in AppShell.xaml en registreer route in AppShell.xaml.cs  
- Maak ProductCategoriesViewModel.  
- Maak ProductCategoriesView.  
- Registreer De view en het ViewModel in MauiProgramm.  
- Zorg dat de ProductCategoriesView gestart kan worden na het klikken op een Category in CategoriesView  
- Registreer route naar ProductCategoriesView in AppShell.xaml.cs  




