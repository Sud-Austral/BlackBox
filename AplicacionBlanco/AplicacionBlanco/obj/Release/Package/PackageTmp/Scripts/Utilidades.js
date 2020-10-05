function OcultarURL(saludo) {
    //alert(saludo);
    var blobMe = URL['createObjectURL'](new Blob([''], { type: 'text/html' }));
    var elIframe = document['createElement']('iframe');
    //elIframe.classList("w-100");
    //elIframe.classList("h-100");

    elIframe['setAttribute']('frameborder', '0');
    elIframe['setAttribute']('width', '100%');
    //elIframe['setAttribute']('height', '100%');
    elIframe['setAttribute']('height', '100vh');
    elIframe['setAttribute']('allowfullscreen', 'true');
    elIframe['setAttribute']('webkitallowfullscreen', 'true');
    elIframe['setAttribute']('mozallowfullscreen', 'true');
    elIframe['setAttribute']('src', blobMe);
    elIframe['setAttribute']('class', "embed-responsive-item");
    elIframe['setAttribute']('style', "background-color:white;");
    var idOne = 'gepa_' + Date.now();
    elIframe['setAttribute']('id', idOne);
    document.getElementById('myframe').appendChild(elIframe);
    const iframeHere = 'http://52.173.85.103:8069/';
    document['getElementById'](idOne)['contentWindow']['document'].write('<script type="text/javascript">location.href = "' + iframeHere + '";</script>')
}