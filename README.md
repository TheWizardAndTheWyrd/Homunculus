                                              _                        _   
  /\  /\___  _ __ ___  _   _ _ __   ___ _   _| |_   _ ___   _ __   ___| |_ 
 / /_/ / _ \| '_ ` _ \| | | | '_ \ / __| | | | | | | / __| | '_ \ / _ \ __|
/ __  / (_) | | | | | | |_| | | | | (__| |_| | | |_| \__ \_| | | |  __/ |_ 
\/ /_/ \___/|_| |_| |_|\__,_|_| |_|\___|\__,_|_|\__,_|___(_)_| |_|\___|\__|
---[		(c) 2016 The Wizard & The Wyrd, LLC - v0.0.1-alpha		   ]---

Summary
=======
Homonculus.NET is an implementation of a Topology Weight Evolving Artificial 
Neural Network written in C#.  The implementation is based upon the
reference implementation in the "Handbook of Neuroevolution Through Erlang".

Since the referecen implementation uses Erlang's actor model for concurrency
and soft real-time concurrency and fault-tolerance, we are using the
Akka.NET library (an actor system implementation based on Scala's Akka).

Service Fabric
==============
Homunculus.NET is using the Service Fabric SDK to build micro-services in
front of our TWEANN.  The Akka actors are going to be distributed over 
each node, and we are using Akka for a large portion of the actors due to
the semantics of Akka.NET's message handling and routing models.  We will
be using some lightweight Service Fabric Actors to facilitate communication
between our TWEANN and our micro-services/JSON APIs.