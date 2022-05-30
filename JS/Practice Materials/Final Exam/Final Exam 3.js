function result(array) {
    let capacity = array.shift();

    let records = {
    }
    let current = array.shift();
    while (current !== "Statistics") {
        let line = current.split("=");
        let [command, name, ...tokens] = line;
        switch (command) {
            case "Add":
                if(!records.hasOwnProperty(name)){
                    let buffer = +tokens;
                    records[name] = buffer;
                }
                break;
            case "Message":
                if(records.hasOwnProperty(name) && records.hasOwnProperty(tokens)){
                    let sender = name;
                    let reciever = tokens.toString();
                        records[sender][0]++;
                        records[reciever][1]++;
                        console.log(typeof records[sender][1]);
                    // if(records[sender][0] + records[sender][1] >= capacity){
                    //     console.log(`${sender} reached the capacity!`);
                    //     delete records[sender];
                    // }
                    // if(records[reciever][0] + reciever[sender][1] >= capacity){
                    //     console.log(`${reciever} reached the capacity!`);
                    //     delete records[reciever];
                    // }
                }
                break;
            case "Empty":
                if(name == "All"){
                    records = {};
                }else{
                    if(records.hasOwnProperty(name)){
                        delete records[name];
                    }
                }
                break;
        }

        current = array.shift();
    }
    let usersCount = Object.keys(records)
    let objectArray = Object.entries(records)
    let sort = {

    }
    console.log(`Users count: ${usersCount.length}`);
    for(let el of objectArray){
        let totalMsg = Number(el[1][0]) + Number(el[1][1]);
        sort[el[0]] = totalMsg;
    }
    let sorted = Object.entries(sort)
    .sort(([, v1], [, v2]) => v2 - v1)
    .reduce((obj, [k, v]) => ({
        ...obj,
        [k]: v
    }),{})
    let newSorted = Object.entries(sorted);
    for(let i = 0;i<newSorted.length;i++){
        console.log(`${newSorted[i][0]} - ${newSorted[i][1]}`)
    }
}
result(["20",
"Add=Mark=3=9",
"Add=Berry=5=5",
"Add=Clark=4=0",
"Empty=Berry",
"Add=Blake=9=3",
"Add=Michael=3=9",
"Add=Amy=9=9",
"Message=Blake=Amy",
"Message=Michael=Amy",
"Statistics"])

