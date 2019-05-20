








// function getVals(){
//     // Get slider values
//     var parent = this.parentNode;
//     var slides = parent.getElementsByTagName("input");
//       var slide1 = parseFloat( slides[0].value );
//       var slide2 = parseFloat( slides[1].value );
//     // Neither slider will clip the other, so make sure we determine which is larger
//     if( slide1 > slide2 ){ var tmp = slide2; slide2 = slide1; slide1 = tmp; }
    
//     var displayElement = parent.getElementsByClassName("rangeValues")[0];
//         displayElement.innerHTML = "$ " + slide1 + "k - $" + slide2 + "k";
//   }
  
//   window.onload = function(){
//     // Initialize Sliders
//     var sliderSections = document.getElementsByClassName("range-slider");
//         for( var x = 0; x < sliderSections.length; x++ ){
//           var sliders = sliderSections[x].getElementsByTagName("input");
//           for( var y = 0; y < sliders.length; y++ ){
//             if( sliders[y].type ==="range" ){
//               sliders[y].oninput = getVals;
//               // Manually trigger event first time to display values
//               sliders[y].oninput();
//             }
//           }
//         }
//   }












// $(document).ready(function() {
//     function addSeperator(nStr) {
//         nStr += '';
//         var x = nStr.split('.');
//         var x1 = x[0];
//         var x2 = x.length > 1 ? '.' + x[1] : '';
//         var rgx = /(\d+)(\d{3})/;
//         while (rgx.test(x1)) {
//             x1 = x1.replace(rgx, '$1' + '.' + '$2');
//         }
//         return x1 + x2;
//     }

//     function rangeInputChangeEventHandler(e){
//         var rangeGroup = $(this).attr('name'),
//             minBtn = $(this).parent().children('.min'),
//             maxBtn = $(this).parent().children('.max'),
//             range_min = $(this).parent().children('.range_min'),
//             range_max = $(this).parent().children('.range_max'),
//             minVal = parseInt($(minBtn).val()),
//             maxVal = parseInt($(maxBtn).val()),
//             origin = $(this).context.className;

//         if(origin === 'min' && minVal > maxVal-5){
//             $(minBtn).val(maxVal-5);
//         }
//         var minVal = parseInt($(minBtn).val());
//         $(range_min).html(addSeperator(minVal*1000) + ' €');

//     }
//     })