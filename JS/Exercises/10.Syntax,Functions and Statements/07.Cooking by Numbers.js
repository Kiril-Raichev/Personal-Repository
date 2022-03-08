function result(num,a,b,c,d,e) {
    let number = +num;
    let array = [];
    array.push(a);
    array.push(b);
    array.push(c);
    array.push(d);
    array.push(e);
    let length = array.length;

    for(let i =0;i<length;i++){
        let current = array.shift();
        switch(current){
            case "chop":
                number /=2;
                console.log(number.toFixed(0));
            break;
            case "dice":
                number = Math.sqrt(number);
                console.log(number.toFixed(0));
            break;
            case "spice":
                number ++;
                console.log(number.toFixed(0));
            break;
            case "bake":
                number *=3;
                console.log(number.toFixed(0));
            break;
            case "fillet":
                number *= 0.8;
                console.log(number.toFixed(1));
            break;
        }
    }
}
result(
    '9', 'dice', 'spice', 'chop', 'bake', 'fillet'

)