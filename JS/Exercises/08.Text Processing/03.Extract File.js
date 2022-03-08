function result(string) {
    let index = string.lastIndexOf("\\"); // indexa na poslednata naklonena cherta
    let fileName = string.substring(index + 1).split(".");
    
    let extension = fileName.pop();
    let template = fileName.join(".");

    console.log(`File name: ${template}`);
    console.log(`File extension: ${extension}`);

}
result(
    'C:\\Internal\\training-internal\\Template.pptx'
)