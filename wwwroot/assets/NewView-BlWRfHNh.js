import{d as r,r as i,c as u,a as o,i as c,v as m,b as d,j as l,h as p,t as f,g as v,k as b}from"./index-BrNi09fd.js";import{_,a as x}from"./PrimaryButton.vue_vue_type_script_setup_true_lang-BTFjoxmV.js";const h={class:"container mx-auto"},k=r({__name:"NewView",setup(w){const e=i({name:"",status:0});function n(){x.post("/api/batches",e.value).then(a=>{a.status===200&&b.push("/batches")})}return(a,t)=>(v(),u("div",h,[o("form",{onSubmit:t[1]||(t[1]=l(s=>n(),["prevent"]))},[c(o("input",{type:"text",class:"p-2 rounded-md border-2 border-black","onUpdate:modelValue":t[0]||(t[0]=s=>e.value.name=s)},null,512),[[m,e.value.name]]),d(_,{innerText:"Submit"})],32),p(" "+f(e.value),1)]))}});export{k as default};