$(document).ready(function(){
    // $(".menu_category").css({"width":$("body").width()});
    // $(".menu_category").offset({left:0});

   $(document).on("mouseenter",".homehower",function(){
       $(".menu_category").css({"visibility":"visible"})
       if( $(".menu_category").css({"visibility":"visible"})){
           $(".menu_category").on("mouseenter",function(){
               $(this).css({"visibility":"visible"});
          })
       }
   })
   $(document).on("mouseleave",".home2",function(){
       $(".menu_category").css("visibility","hidden")
   })

   //Women section

   $(document).on("mouseenter",".homehower2",function(){
    $(".menu_category2").css({"visibility":"visible"})
    if( $(".menu_category2").css({"visibility":"visible"})){
        $(".menu_category2").on("mouseenter",function(){
            $(this).css({"visibility":"visible"});
       })
    }
})
$(document).on("mouseleave",".home3",function(){
    $(".menu_category2").css("visibility","hidden")
})

//Kids section

$(document).on("mouseenter",".homehower3",function(){
    $(".menu_category3").css({"visibility":"visible"})
    if( $(".menu_category3").css({"visibility":"visible"})){
        $(".menu_category3").on("mouseenter",function(){
            $(this).css({"visibility":"visible"});
       })
    }
})
$(document).on("mouseleave",".home4",function(){
    $(".menu_category3").css("visibility","hidden")
})


    $(document).on("mouseenter", ".homehower5", function () {
        $(".menu_category5").css({ "visibility": "visible" })
        if ($(".menu_category5").css({ "visibility": "visible" })) {
            $(".menu_category5").on("mouseenter", function () {
                $(this).css({ "visibility": "visible" });
            })
        }
    })
    $(document).on("mouseleave", ".home5", function () {
        $(".menu_category5").css("visibility", "hidden")
    })



   $(document).on("click","header .menu_search ul li button",function(){
       $(this).css({"border":"none"},{"outline":"none"});
   })

   
})