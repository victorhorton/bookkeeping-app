import{d as m,r as c,o as v,c as s,j as f,i as n,v as r,a as u,b,l as x,h as V,t as _,u as k,g as i,k as y}from"./index-BtBY_pFu.js";import{a as d,_ as N}from"./PrimaryButton.vue_vue_type_script_setup_true_lang-Dtq1vmHR.js";const $={class:"container mx-auto"},C=m({__name:"EditView",setup(g){const l=k(),e=c();v(()=>{d.get(`/api/companies/${l.params.id}`).then(t=>{t.status===200&&(e.value=t.data)})});function p(){e.value&&d.put(`/api/companies/${e.value.id}`,e.value).then(t=>{t.status===204&&y.push("/companies")})}return(t,a)=>(i(),s("div",$,[e.value?(i(),s("form",{key:0,onSubmit:a[2]||(a[2]=f(o=>p(),["prevent"]))},[n(u("input",{type:"text",class:"p-2 rounded-md border-2 border-black","onUpdate:modelValue":a[0]||(a[0]=o=>e.value.name=o)},null,512),[[r,e.value.name]]),n(u("input",{type:"text",class:"p-2 rounded-md border-2 border-black","onUpdate:modelValue":a[1]||(a[1]=o=>e.value.code=o)},null,512),[[r,e.value.code]]),b(N,{innerText:"Submit"})],32)):x("",!0),V(" "+_(e.value),1)]))}});export{C as default};