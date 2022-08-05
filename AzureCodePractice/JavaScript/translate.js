var transEndpoint = 'https://api.cognitive.microsofttranslator.com/';
var transKey = 'a13d0676ecd74de8bd5cc3ebb06d9330';
var transRegion = 'westus2';
var region = 'westus2';


function translate(query, to) {
    var params = `to=${to}`;
    var transUrl = `${transEndpoint}/translate?api-version=3.0&${params}`;

    var data = [{ 'text': query }];
    await $.ajax({
        type: 'POST',
        url: transUrl,
        contentType: 'application/json',
        data: JSON.stringify(data),
        beforeSend:function(xhr){
            xhr.setRequestHeader('Ocp-Apim-Subscription-Key', transKey);
            xhr.setRequestHeader('Ocp-Apim-Subscription-Region', region);
        }
    }).done(function (transResponse) {
        alert(JSON.stringify(transResponse));
        transText = transResponse[0]['translations'][0];
    }).fail(function(err){
        alert(err.responseText)
    })
    return transText
}
