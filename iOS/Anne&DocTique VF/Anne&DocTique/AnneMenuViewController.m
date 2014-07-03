//
//  AnneMenuViewController.m
//  Demo2
//
//  Created by Kapi on 23/05/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "AnneMenuViewController.h"
#import "MasterViewController.h"
//#import "AnneLogViewController.h"
//#import "AnneMultiProductViewController.h"
//#import "AnneProductCluster.h"

@implementation AnneMenuViewController

//static NSString *jsonUrl=@"http:ralf-esgi.com/app6/servicehello.svc/CNF_RetreiveAnecdote/top/1";

- (void)viewDidLoad
{
    [super viewDidLoad];
    self.view.backgroundColor = [UIColor cyanColor];
    NSLog(@"MenuAir's VD did Load");
}

#pragma mark - AnneAirMenuDelegate & DataSource
//Numbre of Session
- (NSInteger)numberOfSession
{
    return 1;
}
//Number Of Title In AirMenu
- (NSInteger)numberOfRowsInSession:(NSInteger)sesion
{
    return 5;
}
//String for Title
- (NSString*)titleForRowAtIndexPath:(NSIndexPath*)indexPath
{
    switch (indexPath.row) {
        case 0:
            return [NSString stringWithFormat:@"Accueil"];;
            break;
            
        case 1:
            return [NSString stringWithFormat:@"VDM"];
            break;
            
        case 2:
            return [NSString stringWithFormat:@"DTC"];
            break;
            
        case 3:
            return [NSString stringWithFormat:@"CNF"];
            break;
            
        case 4:
            return [NSString stringWithFormat:@"Setting"];
            break;
            
        default:
            return [NSString stringWithFormat:@"Erreur de source"];
            break;
    }
    //return [NSString stringWithFormat:@"Row %ld", (long)indexPath.row];// (long)indexPath.section
}
//Title of HeaderView
- (NSString*)titleForHeaderAtSession:(NSInteger)session
{
    return [NSString stringWithFormat:@"Types:"];
}
//viewController for Each Title
- (UIViewController*)viewControllerForIndexPath:(NSIndexPath*)indexPath
{
    MasterViewController * viewController = [[MasterViewController alloc] init];
    //AnneCommunicator *globalVariable =[[AnneCommunicator alloc]init];
    UINavigationController * controller = [[UINavigationController alloc] initWithRootViewController:viewController];
    NSURL *url = nil;//[[NSBundle mainBundle] URLForResource:@"example" withExtension:@"json"];
    //NSError *error;
    //NSData *jsonData;
    
    switch (indexPath.row) {
        case 0:
            //viewController.view.backgroundColor =[UIColor whiteColor];//Acceuil avec toutes les Annecdotes
            url = [[NSBundle mainBundle] URLForResource:@"example" withExtension:@"json"];
            NSLog(@"case : 0  %@",url);
            break;
        case 1:
            //viewController.view.backgroundColor = [UIColor blueColor];//VDM
            url = [[NSBundle mainBundle] URLForResource:@"example" withExtension:@"json"];
            //url =[NSURL URLWithString:@"http://ralf-esgi.com/app6/servicehello.svc/VDM_RetreiveAnecdote/%d/1"];
            //viewController.jsonUrl=@"http://ralf-esgi.com/app6/servicehello.svc/VDM_RetreiveAnecdote/%d/1";
            NSLog(@"case : 1 "); //%@",viewController.jsonUrl);
            break;
        case 2:
            //viewController.view.backgroundColor = [UIColor greenColor];//DTC
            url = [[NSBundle mainBundle] URLForResource:@"example" withExtension:@"json"];
            //url = [[NSString stringWithFormat:@"%@http://ralf-esgi.com/app6/servicehello.svc/DTC_RetreiveAnecdote/%d/1", entry.section] toURL];
            //viewController.jsonUrl=@"http://ralf-esgi.com/app6/servicehello.svc/DTC_RetreiveAnecdote/%d/1";
            NSLog(@"case :2 ");//%@",viewController.jsonUrl);
            break;
        case 3:
            //viewController.view.backgroundColor = [UIColor brownColor];//CNF
            url = [[NSBundle mainBundle] URLForResource:@"example" withExtension:@"json"];
            //url = [[NSString stringWithFormat:@"%@http://ralf-esgi.com/app6/servicehello.svc/CNF_RetreiveAnecdote/%d/1", entry.section] toURL];[NSURL URLWithString:@"http://ralf-esgi.com/app6/servicehello.svc/CNF_RetreiveAnecdote/%d/1"]
            //viewController.jsonUrl=@"http://ralf-esgi.com/app6/servicehello.svc/CNF_RetreiveAnecdote/%d/1";
            NSLog(@"case : 3 ");//%@",viewController.jsonUrl);
            break;
        case 4:
            //viewController.view.backgroundColor =[UIColor purpleColor];//Setting
            NSLog(@"case : 4");//%@",viewController.jsonUrl);
            break;
    }
    NSLog(@"Ending of MenuAir's Switch");
    //jsonData = [NSData dataWithContentsOfURL:url];
    
    /*
     if (jsonData) {
     NSDictionary *dict = [NSJSONSerialization JSONObjectWithData:jsonData options:0 error:&error];
     if (dict) {
     NSArray *specs = dict[@"anecdotes"];
     NSArray *productClusters = [AnneProductCluster productClustersFromSpecs:specs];
     [AnneMultiProductViewController runWithTitle:@"Other"
     productClusters:productClusters
     delegate:self];
     NSLog(@"Json's process was finished");
     }
     else{
     NSLog(@"dictionary was in trouble");
     }
     }
     else{
     NSLog(@"JsonData's process wasn't finished");
     }
     */
    
    return controller;
}

@end
