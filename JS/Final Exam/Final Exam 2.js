function result(input) {
    //let pattern = /@?+#?+(?<colour>[a-z]{3,})#?+@?+[^A-Za-z0-9]+\/(?<qty>\d+)\//g;
    let pattern = /[@#]+(?<color>[a-z]{3,})[@#]+[^A-Za-z0-9]*\/+(?<count>[0-9]+)\/+/;
        let string = input.shift();
    let match = pattern.exec(string);

    if(match != null){
        let {colour, qty} = match.groups;
        qty = +qty;
        console.log(`You found ${qty} ${colour} eggs!`)
    }
    

    
}
result(['@@@@green@*/10/@yel0w@*26*#red#####//8//@limon*@*23*@@@red#*/%^&/6/@gree_een@/notnumber/###purple@@@@@*$%^&*/5/'])



