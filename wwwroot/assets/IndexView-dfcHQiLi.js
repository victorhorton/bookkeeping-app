import{a as l,_}from"./PrimaryButton.vue_vue_type_script_setup_true_lang-Dtq1vmHR.js";import{d as m,r as p,o as f,c as o,a,b as d,w as x,F as v,e as h,f as C,g as i,h as k,t as r}from"./index-BtBY_pFu.js";const w={class:"container mx-auto"},y={class:"flex justify-end"},g={class:"flex-1"},N={class:"flex-1"},V={class:"flex-auto"},D=m({__name:"IndexView",setup(B){const s=p([]);f(()=>{l("/api/Companies").then(t=>{s.value=t.data})});function u(t){l.delete(`/api/companies/${t}`).then(c=>{if(c.status===204){const n=s.value.findIndex(e=>e.id===t);s.value.splice(n,1)}})}return(t,c)=>{const n=C("RouterLink");return i(),o("div",w,[a("div",y,[d(n,{to:"/companies/new",class:"bg-neutral-800 p-2 text-neutral-200 active:text-neutral-300 px-2 my-2 rounded-md"},{default:x(()=>[k("New Company")]),_:1})]),(i(!0),o(v,null,h(s.value,e=>(i(),o("div",{key:e.id,class:"flex my-2"},[a("div",g,r(e.name),1),a("div",N,r(e.code),1),a("div",V,[d(_,{onClick:L=>u(e.id),"inner-text":"Delete Company"},null,8,["onClick"])])]))),128))])}}});export{D as default};