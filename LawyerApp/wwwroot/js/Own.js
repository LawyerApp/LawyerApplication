
 const firstColor='#2d2d2f';
 const secondColor='#FFB400';
 const sign="@@";
 
//  Change Practise Area's section's Color Function
 function changeSectionColor(){
    let sections= document.querySelectorAll(".main-team");
          for(let i=0;i<sections.length;i++){
              if(i%2==0){
                  sections[i].children[1].style.color=secondColor;
                  sections[i].children[0].style.backgroundColor=secondColor;
              }
          }
  }
///////////////////////////////////////////////////

//Seperate Text Function
function seperateText(text){
    let newString="";
    for(let i=0;i<=text.length;i++){
        if(text[i]=="@" && (text[i-1]=="@" || text[i+1]=="@")){
            newString+="<br>";
        }else{
            newString+=text[i];
        }
    }
return newString;
}
// 
