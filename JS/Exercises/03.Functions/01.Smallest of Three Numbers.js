function result(array) {
    let partyList = [];
    for (let i = 0; i < array.length; i++) {
        let current = array[i].split(" ");
        if (current[2] == "going") {
            if (partyList.includes(current[0])) {
                console.log(`${current[0]} is already in the list!`)
            } else {
                partyList.push(current[0]);
            }
        } else if (current[2] == "not") {
            if(partyList.includes(current[0])){
                for(let i =0;i<partyList.length;i++){
                    if(partyList[i] == current[0]){
                        let index = indexOf(partyList[i]);
                        partyList.splice(index, 1);
                    }
                }
            }else{
                console.log(`${current[0]} is not in the list!`)
            }
        }

    }
    console.log(partyList);
}
result(["Allie is going!",
    "George is going!",
    "John is not going!",
    "George is not going!"]
)