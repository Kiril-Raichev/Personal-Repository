function result(string) {
    
    let firstPart = string.substring(0, string.length/2).split("").reverse().join("");
    let secondPart = string.substring(string.length/2, string.length).split("").reverse().join("");
    console.log(firstPart);
    console.log(secondPart);
}
result(
    'tluciffiDsIsihTgnizamAoSsIsihT'
)