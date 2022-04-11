// define  routes
// in each route should map to a component
const routes=[
    { path: '/home', component: home },
  { path: '/societe', component: societe },
  {path:'/persSec',component:persSec},
]
const router = new VueRouter({
 
    routes
})
const app   = new Vue({
    router 
    //this will be mounted to the element with id app 
})