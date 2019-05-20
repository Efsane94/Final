
// $(document).on("click",".categories_menu a",function(){
//     if($(".categories_menu ul li ul").css("display","none")){
//         $(".categories_menu ul li ul").css("display","block")
//     }else{
//         $(".categories_menu ul li ul li").css("display","none")
//     }
// })

$(document).ready(function(){
  $(".categories_menu span").click(function(){
      $(this).siblings().toggle();
  })
})


// $(function() {
//   $('.button-like')
//     .bind('click', function(event) {
//       $(this).toggleClass("liked");
//     })
// });


// $(".button").addEventListener("click", function(){
    
//     $(".selected_product").html = $(this).parents().hasClass("product_wrapper");

// });

  $(".button").click(function(){
    
    var product = $(this).parents(".product_wrapper").clone();
    product.addClass("col-lg-6 col-md-12 col-sm-12 selected_product");
    $(".selected_product .btn_add_cart").remove();
    $(".modalBody").append(product);

});






