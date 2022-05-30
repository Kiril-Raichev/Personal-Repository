function result(array) {

    let production = new Map();

    for(let i = 0; i <array.length;i+=2 ){
        let current = array[i];
        let quantity = +array[i+1];
        
        if(!production.has(current)){
            production.set(current,0);
        }
        let updateQuantity = production.get(current);
        updateQuantity+=quantity;
        production.set(current, updateQuantity);
    }
    for(el of production){
    console.log(`${el[0]} -> ${el[1]}`);
    }
    
}
result([
    'Gold',
    '155',
    'Silver',
    '10',
    'Copper',
    '17'
    ]
    )