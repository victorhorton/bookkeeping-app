import{d,r as l,c as p,a as o,i as n,v as r,b as u,j as m,h as c,t as v,g as f,k as b}from"./index-BtBY_pFu.js";import{_ as x,a as _}from"./PrimaryButton.vue_vue_type_script_setup_true_lang-Dtq1vmHR.js";const V={class:"container mx-auto"},N=d({__name:"NewView",setup(k){const e=l({name:"",code:""});function i(){_.post("/api/companies",e.value).then(s=>{s.status===200&&b.push("/companies")})}return(s,a)=>(f(),p("div",V,[o("form",{onSubmit:a[2]||(a[2]=m(t=>i(),["prevent"]))},[n(o("input",{type:"text",class:"p-2 rounded-md border-2 border-black","onUpdate:modelValue":a[0]||(a[0]=t=>e.value.name=t)},null,512),[[r,e.value.name]]),n(o("input",{type:"text",class:"p-2 rounded-md border-2 border-black","onUpdate:modelValue":a[1]||(a[1]=t=>e.value.code=t)},null,512),[[r,e.value.code]]),u(x,{innerText:"Submit"})],32),c(" "+v(e.value),1)]))}});export{N as default};
