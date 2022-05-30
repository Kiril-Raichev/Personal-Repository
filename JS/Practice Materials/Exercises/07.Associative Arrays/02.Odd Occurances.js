function result(input) {
    let string = input.toLowerCase().split(" ");
    let map = new Map();

    for (let el of string) {
        let num = 0;
        if (map.has(el)) {
            num = map.get(el);
        }
        num++;
        map.set(el, num);
    }
    let entries = Array.from(map); // razdelq mapa na razlichni arrays 
    //s string i broi i vrushta masic ot masivi
    let filtered = entries.filter((el) => {
        return el[1] % 2 !== 0;
    })
    let final = [];
    for(let el of filtered){
        final.push(el[0]);
    }
    console.log(final.join(" "));
}
result(
    'Java C# Php PHP Java PhP 3 C# 3 1 5 C#'
)