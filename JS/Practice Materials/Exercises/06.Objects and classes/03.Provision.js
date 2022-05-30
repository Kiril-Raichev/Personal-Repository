function result(stock,delivery) {

    let storeProducts = {};
    let currentLength = stock.length;
    let deliveryLength = delivery.length;
    for(let i =0;i<currentLength;i+=2){
        let product = stock[i];
        storeProducts[product] = Number(stock[i+1]); 
        // na store products s kluch product 
        //slagame sledvashtiq idex koeto e chislotot
    }

    for(let i = 0; i <deliveryLength;i+=2){
        let product = delivery[i];

        if(!storeProducts.hasOwnProperty(product)){
            storeProducts[product] = 0;

        }
        storeProducts[product] += Number(delivery[i+1]);
    }
    for (let product in storeProducts){
        console.log(`${product} -> ${storeProducts[product]}`);
    }
    
}
result([
    'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'
    ],
    [
    'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30'
    ]
    )