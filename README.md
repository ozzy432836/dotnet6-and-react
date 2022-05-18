A genine experiment to build a react app using technology I already know.

.Net MVC

MVC handles the server side rendering and the part I actually want to react, I have used a simple call to a React/JSX lib.

Having a few problems because I realise there are 10 different react apps on the page (basically one per product)
What happens if there are a 1000 products
We can hack round that by paging and making a maximum of 30 products per page...but thats a bit of an anti pattern

Also there will still be 30 react apps on the page and they would need local storage to communicate with the common basket.

Each add or remove button would have to parse and stringify the basket in local storage to see if its in there and then add/remove another instance of itself.

This seems like a dead end.