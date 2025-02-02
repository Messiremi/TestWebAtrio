# TestWebAtrio
Test technique web atrio

Run:
front: npm start in  EmployeeMaster.Web -- non terminé faute de temps depassé
back: compile and run EmployeeMaster.Api project
Doc API: https://localhost:7168/swagger/index.html

Auto critique:
création back peut être trop longue
création front hasardeuse car très peu de contact avec React étant habitué au front Blazor
beaucoup de temps sur des détails (confort, organisation)
coding avec un framework inconnu demande du temps d'apprentissage

# Database
Database in memory ajoutée dans le backend plutot qu'une db physique, pas de besoins pour un test
Structure:
table Employee modélisant un employé, Employment modelisant les emplois avec lien vers Employee (on considère que chaque emplois est une propriété d'un employé, relation 1-n, et non des emplois existant pouvant être attribués a des personnes qui aurait donné du n-n)

# Backend
2025/01/01
17:35 - 18:30 : mise en place de l'archi + db
18:30 - 19:20 : mise en place de la logique metier
19:20 - 20:25 : mise en place de l'api et troubleshooting
total = 2h50

# Frontend
2025/01/02
17:15 - 17:25 : initialisation projet
17:25 - 17:45 : layout, style and navigation
17:50 - 18:30 : creation des pages - limite temps
total = 1h10

# Tools & resources
Visual studio (2022)
Microsoft documentation
Stackoverflow
Github
Postman
React get started website
routing react https://hygraph.com/blog/routing-in-react