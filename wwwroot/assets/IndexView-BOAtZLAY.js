import{a as l,_}from"./PrimaryButton.vue_vue_type_script_setup_true_lang-Dtq1vmHR.js";import{d as f,r as m,o as x,c as o,a as n,b as d,w as p,F as v,e as h,f as k,g as c,h as w,t as r}from"./index-BtBY_pFu.js";const y={class:"container mx-auto"},C={class:"flex justify-end"},g={class:"flex-1"},A={class:"flex-1"},N={class:"flex-auto"},$=f({__name:"IndexView",setup(V){const s=m([]);x(()=>{l("/api/Accounts").then(t=>{s.value=t.data})});function u(t){l.delete(`/api/accounts/${t}`).then(i=>{if(i.status===204){const a=s.value.findIndex(e=>e.id===t);s.value.splice(a,1)}})}return(t,i)=>{const a=k("RouterLink");return c(),o("div",y,[n("div",C,[d(a,{to:"/accounts/new",class:"bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 px-2 my-2 rounded-md"},{default:p(()=>[w("New Account")]),_:1})]),(c(!0),o(v,null,h(s.value,e=>(c(),o("div",{key:e.id,class:"flex my-2"},[n("div",g,r(e.number),1),n("div",A,r(e.name),1),n("div",N,[d(_,{onClick:b=>u(e.id),"inner-text":"Delete Account"},null,8,["onClick"])])]))),128))])}}});export{$ as default};
