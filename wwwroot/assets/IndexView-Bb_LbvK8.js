import{a as c,_ as m}from"./PrimaryButton.vue_vue_type_script_setup_true_lang-BTFjoxmV.js";import{d as x,r as p,o as v,c as o,a as s,b as i,w as r,F as h,e as C,f as k,g as d,h as u,t as _}from"./index-BrNi09fd.js";const g={class:"container mx-auto"},w={class:"flex justify-end"},N={class:"flex-1"},V={class:"flex-1"},$={class:"flex-auto"},b={class:"flex-auto"},E=x({__name:"IndexView",setup(B){const a=p([]);v(()=>{c("/api/Companies").then(t=>{a.value=t.data})});function f(t){c.delete(`/api/companies/${t}`).then(l=>{if(l.status===204){const n=a.value.findIndex(e=>e.id===t);a.value.splice(n,1)}})}return(t,l)=>{const n=k("RouterLink");return d(),o("div",g,[s("div",w,[i(n,{to:"/companies/new",class:"bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 rounded-md"},{default:r(()=>[u("New Company")]),_:1})]),(d(!0),o(h,null,C(a.value,e=>(d(),o("div",{key:e.id,class:"flex my-2"},[s("div",N,_(e.name),1),s("div",V,_(e.code),1),s("div",$,[i(n,{to:`/companies/edit/${e.id}`,class:"bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 rounded-md"},{default:r(()=>[u("Edit")]),_:2},1032,["to"])]),s("div",b,[i(m,{onClick:L=>f(e.id),"inner-text":"Delete"},null,8,["onClick"])])]))),128))])}}});export{E as default};
