function result(arr1,arr2) {

    for(let i = 0;i<arr1.length;i++){
        let currElem1= arr1[i];
        for(let j =0;j<arr2.length;j++){
            let currElem2 = arr2[j];

            if(currElem1 === currElem2){
                console.log(currElem1);
            }
        }
    }
}
result(['Hey', 'hello', 2, 4, 'Peter', 'e'],
    ['Petar', 10, 'hey', 4, 'hello', '2'])