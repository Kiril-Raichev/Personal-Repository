function result(a) {
    let string = a;
    let stringToArray = string.split(/\W/);
    let length = stringToArray.length;
    let newArray = [];
    for (let i = 0; i < length; i++) {
        if(stringToArray[i].length>0){
            newArray.push(stringToArray[i]);
        }
    }
    console.log(newArray.join(", ").toUpperCase())
}
result(
    'Hi, how are you?'
)