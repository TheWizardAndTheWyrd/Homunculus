                                              _                        _   
  /\  /\___  _ __ ___  _   _ _ __   ___ _   _| |_   _ ___   _ __   ___| |_ 
 / /_/ / _ \| '_ ` _ \| | | | '_ \ / __| | | | | | | / __| | '_ \ / _ \ __|
/ __  / (_) | | | | | | |_| | | | | (__| |_| | | |_| \__ \_| | | |  __/ |_ 
\/ /_/ \___/|_| |_| |_|\__,_|_| |_|\___|\__,_|_|\__,_|___(_)_| |_|\___|\__|
---[		(c) 2015 The Wizard & The Wyrd, LLC - v0.0.1-alpha		   ]---

Summary
=======
Homonculus.NET is an implementation of a Topology Weight Evolving Artificial 
Neural Network written in C#.  The implementation is based upon the
reference implementation in the "Handbook of Neuroevolution Through Erlang".

Since the referecen implementation uses Erlang's actor model for concurrency
and soft real-time concurrency and fault-tolerance, we are using the
Akka.NET library (an actor system implementation based on Scala's Akka).

Road Map
========
Homunculus.NET is planned to be used in another project of ours called
[OpenLisp.NET](https://bitbucket.org/wizardbeard/openlisp.net).  Basically,
Homunculus.NET will serve as a powerful artificial neural network that our
Lisp variant will use, under the hood, to provide powerful capabilities to
both projects.  OpenLisp.NET<sup>TM</sup> will gain a powerful TWEANN platform and 
Homunculus.NET will gain a usable and extensible Lisp capable of performing
machine learning and meta-programming (using our BlockExpressionActor and other
techniques).  Once the first iteration of the TWEANN platform is complete,
packages will be published to NuGet, OpenLisp.NET will use the NuGet packages
to reference Homunculus.NET maintaining a clean separation of concerns and
problem domains/design spaces.

Akka.NET
========
Homunculus.NET<sup>TM</sup> is the first iteration of the Homunculus 
Platform<sup>TM</sup>.  Akka.NET is a port to the CLR of the popular Akka
framework to implement Erlang-style actors on the JVM.  As we are developing
a JVM version of the Homunculus Platform using Java EE and Akka, writing
our actors in Akka.NET will allow for a smooth port to the JVM.  We aim to
provide rich cross-platform capability by sharing data types that serialize
to a common JSON format for transportation of objects to and from CLR/.NET 
to and from the JVM.

Service Fabric
==============
Homunculus.NET is using the Service Fabric SDK to build micro-services in
front of our TWEANN.  The Akka actors are going to be distributed over 
each node, and we are using Akka for a large portion of the actors due to
the semantics of Akka.NET's message handling and routing models.  We will
be using some lightweight Service Fabric Actors to facilitate communication
between our TWEANN and our micro-services/JSON APIs.

Porting to Java EE 7
====================
The JVM version of the Homunculus Platform<sup>TM</sup> is being built on
Java EE using the Akka framework and Java 8 (with some Scala if/when needed).
Naturally, NetBeans is our IDE of choice for developing Java EE software, and
we are excited about sharing cross-platform TWEANN capabilities across 
heterogeneous platforms and architectures using a common language, semantics,
and set of rich APIs.

OpenLisp.NET
============
As mentioned above, OpenLisp.NET is positioned to be the systems language of
choice for the Homunculus Platform.  Why not use Clojure?  That's a great
question.  We have always wanted to make our tailor-made LISP using both a 
top-down and bottom-up approach; sepcifically for creating a next-generation
LISP Machine.  One of the projects for OpenLisp.NET comprises of creating a
research OS using the [Cosmos OS Construction Kit](https://github.com/CosmosOS/Cosmos).
Why create another OS?  Frankly, because we can, and the research is interesting.

(Plan B on the OpenLisp Machine is to boot a minimal Linux or BSD kernel, and use
a Clojure REPL as the basis of our shell with the OpenLisp libraries ported to
Clojure.  The research is fulfilling, but we want Developers and Hackers to be
productive without fighting their tools.)