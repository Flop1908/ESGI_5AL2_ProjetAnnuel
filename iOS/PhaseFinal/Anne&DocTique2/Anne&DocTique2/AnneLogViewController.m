//
//  AnneLogViewController.m
//  Anne&DocTique2
//
//  Created by Kapi on 28/05/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import "AnneLogViewController.h"
#import "AnneMultiProductViewController.h"
#import "AnneProductCluster.h"

@interface AnneLogViewController ()

@end

@implementation AnneLogViewController
- (IBAction)usernamesEditingBegin:(id)sender {
}
- (IBAction)userNamesDidEnd:(id)sender {
}
- (IBAction)passwordBegin:(id)sender {
}
- (IBAction)passwordDidFinished:(id)sender {
}
- (IBAction)checkingLogIn:(id)sender {
    bool checking =0;
    int mdp=1;
    int login=1;
    
    if(mdp ==1 && login==1)//remplacer 1par le mot de passe en registrer sur le serveur ou la intern database meme pour le login
    {
        checking =1;
    }
    if(checking==1){
        NSURL *url = [[NSBundle mainBundle] URLForResource:@"example" withExtension:@"json"];
        NSError *error;
        NSData *jsonData = [NSData dataWithContentsOfURL:url];
        if (jsonData) {
            NSDictionary *dict = [NSJSONSerialization JSONObjectWithData:jsonData options:0 error:&error];
            if (dict) {
                NSArray *specs = dict[@"productSpecs"];
                NSArray *productClusters = [AnneProductCluster productClustersFromSpecs:specs];
                [AnneMultiProductViewController runWithTitle:@"Other Apps"
                                            productClusters:productClusters
                                                   delegate:self];
            }
        }
    }
    else{
        NSLog(@"Erreur de Mot de Passe");
    }
}
- (void)multiProductViewControllerDidFinish:(AnneMultiProductViewController *)viewController {
    NSLog(@"Json's process was finished");
}

- (IBAction)registration:(id)sender {
    //lancé le programme d'enregistrement
}


- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
