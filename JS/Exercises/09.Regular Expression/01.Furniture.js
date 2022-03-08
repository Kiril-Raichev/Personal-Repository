function result(input) {
    let pattern = /^>>(?<name>[A-Za-z]+)<<(?<price>\d+(?:\.\d+)?)!(?<qty>\d+)$/;
    let furniture = [];
    let total = 0;

    while (input[0] != 'Purchase') {
        let line = input.shift();
        let match = pattern.exec(line);
        if (match != null) {
            let { name, price, qty } = match.groups;
            price = +price;
            qty = +qty;
            total += price * qty;
            furniture.push(name);
        }

    }
    console.log('Bought furniture:');
    for(let el of furniture){
        console.log(el);
    }
    console.log(`Total money spend: ${total.toFixed(2)}`)
    
}
result(
    ['>>Sofa<<312.23!3',
        '>>TV<<300!5',
        '>Invalid<<!5',
        'Purchase']
)






