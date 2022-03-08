function test(input) {
    let productCount = +input.shift();
    const pattern = /@#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+/;

    while(productCount > 0){
        let current = input.shift();
        let match = pattern.exec(current);

        if(match){
            let productGroup = '';
            let product = match.groups.product;
            for(let ch of product){
                let isNumber = +ch;
                if(isNumber * 1 === isNumber){
                    productGroup+=ch;
                }
            }
            if(productGroup === ''){
                productGroup = '00';
            }
            console.log(`Product group: ${productGroup}`);
        }else{
            console.log('Invalid barcode');
        }
        productCount--;
    }
}
test(["6",
    "@###Val1d1teM@###",
    "@#ValidIteM@#",
    "##InvaliDiteM##",
    "@InvalidIteM@",
    "@#Invalid_IteM@#",
    "@#ValiditeM@#"
])